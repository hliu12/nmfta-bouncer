"""Auth module for the firewall app"""

from datetime import timedelta
from flask import jsonify, make_response
from flask_restful import Resource, reqparse
from flask_jwt_extended import (create_access_token)
from models import UserModel

PARSER = reqparse.RequestParser()
PARSER.add_argument("username")
PARSER.add_argument("password")
PARSER.add_argument("grant_type")

class Register(Resource):
    """Register Class"""
    @classmethod
    def post(cls):
        """Handles post register requests"""
        data = PARSER.parse_args()
        if data['username'] is None:
            return make_response(jsonify(Result={"Status":"Invalid","Error":"1001"}), 400)
        if len(data['username']) > 32:
            return make_response(jsonify(Result={"Status":"Invalid","Error":"1004"}), 400)
        if data['password'] is None:
            return make_response(jsonify(Result={"Status":"Invalid","Error":"1002"}), 400)
        if len(data['password']) is 0:
            return make_response(jsonify(Result={"Status":"Invalid","Error":"1005"}), 400)

        if UserModel.lookup_user(data['username']):
            return make_response(jsonify(Result={"Status":"Invalid","Error":"1003"}), 400)
        user = UserModel(
            username=data['username'],
            password=UserModel.gen_hash(data['password']))
        user.save()
        return jsonify(message='all good with user creation')

class Login(Resource):
    """Login Class"""
    @classmethod
    def post(cls):
        """Handles post login requests"""
        minutes_valid = 10
        exp_time = timedelta(days=0, hours=0, minutes=minutes_valid) #set token valid time to 10 minutes
        data = PARSER.parse_args()
        if not data['username']:
            return make_response(jsonify(Result={"Status":"Invalid","Error":"2000"}), 400)
        if not data['password']:
            return make_response(jsonify(Result={"Status":"Invalid","Error":"2001"}), 400)
        user = UserModel.lookup_user(data['username'])
        if data['grant_type'] != 'password':
            return make_response(jsonify(Result={"Status":"Invalid","Error":"2002"}), 400)
        if not user:
            return make_response(jsonify(Result={"Status":"Invalid","Error":"2003"}), 400)

        if UserModel.verify_hash(data['password'], user.password):
            access_token = create_access_token(identity=data['username'], expires_delta=exp_time)
            return jsonify(
                access_token=access_token,
                token_type="bearer",
                expires_in=(minutes_valid*60),
                claim_level="complete"
            )
        return make_response(jsonify(Result={"Status":"Invalid","Error":"2003"}), 400)

class BrokenHTTPS(Resource):
    """BrokenHTTPS Class"""
    @classmethod
    def post(cls):
        """Handles post login requests if a valid HTTPS cert isn't found"""
        return make_response(jsonify(message='Valid HTTPS cert does not exist'), 400)
