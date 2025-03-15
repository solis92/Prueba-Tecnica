Clone Repository
Execute the SQL script, it will create the required tables
Then execute the debugger with F5 you should see the swagger display
From there are 3 API, Register, Login, News
Use the register API to create an account
Login with the account, it will draft a bearer token, parse it to postman as a bearer token
this is the uri elements is the number of rows
http://localhost:5159/api/News/{elements}

if for any reason got any problem with using the bearer token, contact me, or else in the class
Newscontroller you only need to comment the Authorize line

There are some screenshots to guide the process

Well to avoid performance issues all the callbacks are asynchronous
Furthermore I though a way to avoid to consult many times the same id from the hacker API
Using SQL I create a row for the first time that any id is consumed
Using this method the number of petitions to the API got reduced drastically

Also I added the JWT auth to validate the News API, so not anybody can use it.

