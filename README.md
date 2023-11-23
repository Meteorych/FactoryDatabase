# FactoryDatabase
Database and interface for this database that give opportunity to make queries. GUI is quite bad, but in overall this is my first project that includes interaction between database and Windows Forms, so for me this is quite interesting expericence.

**Used tools:**
* PostgreSQL, fucntions were wtitten using Pl/PgSQL;
* PGAdmin;
* Windows forms and C#.

**Program's interface**:
![Interface image](https://github.com/Meteorych/FactoryDatabase/blob/master/Images/Interface.png)

All _Manage table_ buttons are used to delete/add/edit onfromation from sql-tables. Other buttons are used to view certain information from tables in component DataGridView. 
Fro example, this is showcase of using _Show table_ button work:
![Program's work image](https://github.com/Meteorych/FactoryDatabase/blob/master/Images/tableshow.png)

When parameters are wrong or user doesn't fill required parameters then program show text of exception in special _MessageBox_. Example of this: 
![Exception example](https://github.com/Meteorych/FactoryDatabase/blob/master/Images/Exception.png)

# License
Program is open source and available under the [MIT License](https://github.com/Meteorych/FactoryDatabase/blob/master/LICENSE.txt).
