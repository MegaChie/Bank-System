import requests as req
import json

port_number = input("What is the port number of the API?\n")
sender = input("What's the account ID of the doner?\n")
begger = input("What is the account ID of the benifitier?\n")
cash = input("How much whould you like to give?\n")
payload = {"fromAccountId": sender,
           "toAccountId": begger,
           "amount": cash}
head = {"Content-Type": "application/json"}

url = "http://localhost:{}/api/accounts/transfer".format(port_number)
with req.post(url, data=json.dumps(payload), headers=head) as marko:
    polo = marko.json()
    print(polo)
