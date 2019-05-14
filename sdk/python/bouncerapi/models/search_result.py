# -*- coding: utf-8 -*-

"""
    bouncerapi

    This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
"""

import bouncerapi.models.ip_address_entry_pair

class SearchResult(object):

    """Implementation of the 'SearchResult' model.

    TODO: type model description here.

    Attributes:
        input_ip (string): the input search string, with the proper '/' in
            CIDR, not '+' as needed in the endpoint URL
        entries (list of IPAddressEntryPair): matching IP Address and Object
            Entry IDs

    """

    # Create a mapping from Model property names to API property names
    _names = {
        "input_ip":'Input_IP',
        "entries":'Entries'
    }

    def __init__(self,
                 input_ip=None,
                 entries=None):
        """Constructor for the SearchResult class"""

        # Initialize members of the class
        self.input_ip = input_ip
        self.entries = entries


    @classmethod
    def from_dictionary(cls,
                        dictionary):
        """Creates an instance of this model from a dictionary

        Args:
            dictionary (dictionary): A dictionary representation of the object as
            obtained from the deserialization of the server's response. The keys
            MUST match property names in the API description.

        Returns:
            object: An instance of this structure class.

        """
        if dictionary is None:
            return None

        # Extract variables from the dictionary
        input_ip = dictionary.get('Input_IP')
        entries = None
        if dictionary.get('Entries') != None:
            entries = list()
            for structure in dictionary.get('Entries'):
                entries.append(bouncerapi.models.ip_address_entry_pair.IPAddressEntryPair.from_dictionary(structure))

        # Return an object of this model
        return cls(input_ip,
                   entries)


