# -*- coding: utf-8 -*-

"""
    bouncerapi

    This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io ).
"""


class Result4(object):

    """Implementation of the 'Result4' model.

    TODO: type model description here.

    Attributes:
        status (string): TODO: type description here.
        message (string): an optional message
        entry_id (string): a unique identifier for the newly created IP
            Address; opaque but likely a GUID

    """

    # Create a mapping from Model property names to API property names
    _names = {
        "status":'Status',
        "entry_id":'EntryID',
        "message":'Message'
    }

    def __init__(self,
                 status=None,
                 entry_id=None,
                 message=None):
        """Constructor for the Result4 class"""

        # Initialize members of the class
        self.status = status
        self.message = message
        self.entry_id = entry_id


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
        status = dictionary.get('Status')
        entry_id = dictionary.get('EntryID')
        message = dictionary.get('Message')

        # Return an object of this model
        return cls(status,
                   entry_id,
                   message)


