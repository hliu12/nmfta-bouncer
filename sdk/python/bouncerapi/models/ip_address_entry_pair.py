# -*- coding: utf-8 -*-

"""
    bouncerapi

    This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
"""


class IPAddressEntryPair(object):

    """Implementation of the 'IP Address Entry Pair' model.

    A shorter version of the IP Address Object used to return the CIDR form
    and an entry to be used for future reference

    Attributes:
        entry_id (string): a unique identifier for the newly created Geo
            Location; opaque but likely a GUID
        i_pv_4 (string): IP Address v4 in CIDR Format. Either IPv4 or IPv6
            MUST be present.

    """

    # Create a mapping from Model property names to API property names
    _names = {
        "entry_id":'EntryID',
        "i_pv_4":'IPv4'
    }

    def __init__(self,
                 entry_id=None,
                 i_pv_4=None):
        """Constructor for the IPAddressEntryPair class"""

        # Initialize members of the class
        self.entry_id = entry_id
        self.i_pv_4 = i_pv_4


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
        entry_id = dictionary.get('EntryID')
        i_pv_4 = dictionary.get('IPv4')

        # Return an object of this model
        return cls(entry_id,
                   i_pv_4)


