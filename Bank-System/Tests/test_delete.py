import requests as req

port_number = input("What is the port number of the API?\n")
accountID = input("I need to the account ID first" +
                  "if you intend to delete the account\n")

url = "http://localhost:{}/api/accounts/{}".format(port_number,
                                                       accountID)
with req.get(url) as marko:
    polo = marko.json()
    print(polo)
