import requests as req
import sys

port_number = input("What is the port number of the API?\n")
accountID = input("I need to the account ID first" +
                  " and then gives you the needed transaction history?\n")

url = "http://localhost:{}/api/transactions/{}".format(port_number,
                                                       accountID)
with req.get(url) as marko:
    polo = marko.json()
    print(polo)
    # assert marko.status_code == 200
    # assert isinstance(polo, float)
