# -*- coding: utf-8 -*-

"""
    bouncerapi

    This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
"""

import jsonpickle
import dateutil.parser
from .controller_test_base import ControllerTestBase
from ..test_helper import TestHelper
from bouncerapi.api_helper import APIHelper


class WhitelistControllerTests(ControllerTestBase):

    @classmethod
    def setUpClass(cls):
        super(WhitelistControllerTests, cls).setUpClass()
        cls.controller = cls.api_client.whitelist

    # This will list the entire contents of the Whitelist including both IP Addresses and Geo Locations.
    def test_all_contents_1(self):

        # Perform the API call through the SDK function
        result = self.controller.all_contents()

        # Test response code
        self.assertEquals(self.response_catcher.response.status_code, 200)

        # Test headers
        expected_headers = {}
        expected_headers['content-type'] = None

        self.assertTrue(TestHelper.match_headers(expected_headers, self.response_catcher.response.headers))

        
        # Test whether the captured response is as we expected
        self.assertIsNotNone(result)
        self.assertEqual('{  "Result": {    "Status": "Success",    "Message": ""  },  "IPAddresses": [    [      "884d9804999fc47a3c2694e49ad2536a",      "192.168.100.14/24"    ]  ],  "GeoLocations": [    "884d9804999fc47a3c2694e49ad2536a#CA"  ]}', self.response_catcher.response.raw_body)


