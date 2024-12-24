import requests as req
import json

port_number = input("What is the port number of the API?\n")
accountID = input("What's the account ID that you wish to" +
                  " add money to?\n")
amount = input("How much cash have you got there?\n")
payload = {"amount": amount,
           "accountID": accountID}
head = {"Content-Type": "application/json"}


url = "http://localhost:{}/api/accounts/deposit".format(port_number)
with req.post(url, data=json.dumps(payload), headers=head) as marko:
    polo = marko.json()
    print(polo)
