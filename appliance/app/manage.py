"""Firewall module for the firewall app"""

from flask import jsonify
import netaddr
from flask_restful import Resource, reqparse
from flask_jwt_extended import jwt_required
from models import IPModel, GeoModel

PARSER = reqparse.RequestParser()
PARSER.add_argument("IPv4", required=False)
PARSER.add_argument("IPv6", required=False)
PARSER.add_argument("Start_Date", required=False)
PARSER.add_argument("End_Date", required=False)
PARSER.add_argument("Comments", required=False)
PARSER.add_argument("Active", required=False)

class Checker(object): # pylint: disable=too-few-public-methods
    """
    Check class allows switching between Whitelist and Blacklist
    from the Resource call by switching a Class variable from "wl" to "bl"
    This lets us use the same CRUD functions for Whitelist and Blacklist
    Maximizes code reuse while maintaining flexibility
    """
    def __init__(self, ltype):
        self.ltype = ltype

class Lists(Checker, Resource):
    """This provides an array of whitelist (1...n) entries. The Whitelists
    should include both the IP Address Entries and Geolocation Entries"""
    @jwt_required
    def get(self):
        """Handles get IpGeoList requests"""
        return jsonify(
            Result={
                "Status":"Success",
                "Message":"Showing All IPs and Geo"
            },
            IPAddresses=IPModel.get_all_ip(self.ltype),
            GeoLocations=GeoModel.get_all_geo(self.ltype)
        )

class IpList(Checker, Resource):
    """This provides an array of whitelisted IP Addresses."""
    @jwt_required
    def get(self):
        """Handles get IpList requests"""
        return jsonify(
            Result={
                "Status":"Success",
                "Message":"Showing All IPs"
            },
            IPAddresses=IPModel.get_all_ip(self.ltype),
        )

class SearchIpList(Checker, Resource):
    """This provides an end-point to look for the whitelisted IP Addresses.
    If a country code is passed, the list of all available IP Address Entries
    for the passed in country code should be returned
    shows IPs with entry_id in front"""
    @jwt_required
    def get(self, filter_term):
        """Handles get EntrySearch requests
        CIDR addresses need to be passed with + instead of /
        as / breaks the REST implimentation"""
        search_results = []
        for search_ip in str(filter_term).split(","):
            if "+" in search_ip:
                search_ip = search_ip.replace("+", "/")
                for sub_ip in netaddr.IPNetwork(search_ip).iter_hosts():
                    found_ip = IPModel.search(str(sub_ip), self.ltype)
                    if found_ip:
                        search_results.append(str(found_ip.id)+"#"+found_ip.ipv4)
            else:
                found_ip = IPModel.search(search_ip, self.ltype)
                if found_ip:
                    search_results.append(str(found_ip.id)+"#"+found_ip.ipv4)
        return jsonify(
            Result={
                "Status":"Success",
                "Message":"Showing All Matching"
            },
            SearchResult={
                "Input_IP":search_ip,
                "Entries":search_results})

class IpEntry(Checker, Resource):
    """This provides detail information about an individual whitelisted entry"""
    @jwt_required
    def get(self, entry):
        """Handles get Entry requests"""
        info = IPModel.get_entry(entry, self.ltype)
        if info is not None:
            return jsonify(
                Result={
                    "Status":"Success",
                    "Message":"Showing Matching Entry"
                },
                Entry={
                    "IPv4":info.ipv4, "IPv6":info.ipv6, "Start_Date":info.start_date,
                    "End_Date":info.end_date, "Comments":info.comments, "Active":info.active}
            )
        return jsonify(
            Result={
                "Status":"Error",
                "Message":"No Matching Entry"})

class CreateIpEntry(Checker, Resource):
    """This method is used to add a whitelist entry"""
    @jwt_required
    def post(self):
        """Handles post CreateIpEntry"""
        data = PARSER.parse_args()
        entry_ip = data["IPv4"] if data["IPv4"] else ""
        entry_ip = data["IPv6"] if data["IPv6"] else entry_ip
        if entry_ip == "":
            return jsonify(
                Result={
                    "Status":"Invalid",
                    "Message":"Must enter IPv4 or IPv6 address"})
        #check if already in database

        new_ip = IPModel(lt=self.ltype, ipv4=data['IPv4'], ipv6=data['IPv6'], start_date=data['Start_Date'],
                     end_date=data['End_Date'], comments=data['Comments'], active=data["Active"], remove=False)
        new_ip.save()
        return jsonify(
            Result={
                "Status":"Success",
                "Message":"IP Added",
                "Entry ID":str(new_ip.id)})

class UpdateIpEntry(Checker, Resource):
    """This method is used to update an existing list entry"""
    @jwt_required
    def post(self, entry):
        """Handles post CreateIpEntry"""
        data = PARSER.parse_args()
        entry_id = IPModel.update_entry(entry, data, self.ltype)
        if not entry:
            return jsonify(
                Result={
                    "Status":"Error",
                    "Message":"No Matching Entry"})
        return jsonify(
            Result={
                "Status":"Success",
                "Message":"IP Updated",
                "Entry ID":str(entry_id)})


class DeleteIpEntry(Checker, Resource):
    """This method is used to delete a listed entry"""
    @jwt_required
    def get(self, entry):
        """Handles delete DeleteIpEntry"""
        data = PARSER.parse_args()
        entry_id = IPModel.delete_entry(entry, self.ltype)
        if not entry:
            return jsonify(
                Result={
                    "Status":"Error",
                    "Message":"No Matching Entry"})
        return jsonify(
            Result={
                "Status":"Success",
                "Message":"IP Deleted",
                "Entry ID":str(entry_id)})

class GeoList(Checker, Resource):
    """This provides an array of listed Geolocation Entries"""
    @jwt_required
    def get(self):
        """Handles get GeoList requests"""
        return jsonify(
            Result={
                "Status":"Success",
                "Message":"Showing All IPs"
            },
            IPAddresses=GeoModel.get_all_geo(self.ltype),
        )
