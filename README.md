# Self-Hosted Assistant on [Heroku](http://heroku.com)

Self-Hosted Assistant is a free, open, simple scheduling application.

This repository holds the API needed for the Assistant 

[![Deploy](https://www.herokucdn.com/deploy/button.svg)](https://heroku.com/deploy)

Once the Heroku app is deployed , follow the below steps to complete the setup :

1. Click Manage App for the application created.
2. Go to resources tab and click the "mLab MongoDB" , it will open a new tab with the mongo db confiugration.
3. Create a new user with all permission to the database in the User -> Add database user.
4. Copy the URI value from the mLab from the section which says "To connect using a driver via the standard MongoDB URI "
5. Go back to the hero0ku application config page.
6. Click the setting tab and reveal config vars and edit the config value for "MONGODB_URI"
7. Paste the URI from mLab page. This value must correspond to the mongodb URI with user name and password with the below format
  mongodb://<dbusername>:<password>@ds063170.mlab.com:63170/heroku_qc6wr6qx
