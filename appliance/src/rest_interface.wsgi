#! /usr/bin/python3.5

import logging
import sys
logging.basicConfig(stream=sys.stderr)
sys.path.insert(0, '/opt/bouncer/src/')
from rest_interface import APP as application
application.secret_key = 'anything you wish'
