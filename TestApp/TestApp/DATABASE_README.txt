DATABASE DOCUMENTATION

- MongoDB
- Managed by Thinh Dinh (Tim). Email: timdinh2020@gmail.com. Phone: 610-451-7996. Feel free to contact me for any questions/requests

HOW TO USE MONGODB IN BACKEND:
1. Create a mongodb object (ex: mongodb myDB = new mongodb();)
2. Call any method using the mongodb object (ex: myDB.db_createAcct(newAccount);)

AVAILABLE DATABASE FUNCTIONS:

        // accounts Collection **************************************************
        /*
         * 
         * Function:     db_getAcctByEmail
         * 
         * Description:  Get the account obj that matches the email
         * 
         * Parameters:   string email_: to be used to identify Account object in database
         * 
         * Return value: List<Account> - returns the list of account obj found in database
         *
         * HOW-TO: db_getAcctByEmail(string "timSOB@gmail.com");
         * 
         */

         /*
         * 
         * Function:     db_createAcct
         * 
         * Description:  Insert new account to the database
         * 
         * Parameters:   Account newAcct - contains new account info
         * 
         * Return value: None
         *
         * HOW-TO: db_createAcct(Account newAcct);
         * 
         */

         /*
         * 
         * Function:     db_updateFieldById
         * 
         * Description:  Get the account obj that matches the email
         * 
         * Parameters:   BsonObjectId Id_ - to be used to identify Account object in database
         *               string field_name - the field name of the account obj
         *               string value - new value to the field name
         *               
         * Return value: None
         *
         * HOW-TO: db_updateFieldById(BsonObjectId Id_);
         *
         */