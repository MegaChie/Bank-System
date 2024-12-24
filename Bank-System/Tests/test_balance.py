#!/usr/bin/python3
import requests as req

port_number = input("What is the port number of the API?\n")
accountID = input("What's the account ID that you wish to" +
                  "check the balance of?\n")

url = "http://localhost:{}/api/accounts/{}/balace".format(port_number,
                                                           accountID)
with req.get(url) as marko:
    try:
        polo = marko.json()
        print(polo)
        # assert marko.s
        # assert isinstance(polo, float)
    except:
        print(marko.content.decode())
