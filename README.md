Clone Repository
Execute the SQL script, it will create the required tables
Then execute the debugger with F5 you should see the swagger display
Frome there are 3 API, Register, Login, News
Use the register API to create an account
Login with the account, it will draft a bearer token, parse it to postman as a bearer token
this is the uri elements is the number of rows
http://localhost:5159/api/News/{elements}

if for any reason got any problem with using the bearer token, contact me, or else in the class
Newscontroller you only need to comment the Authorize line
