# QueryEngine
Answer for an housework for Student C#/.NET Backend Developer Position at Hibernating Rhinos

### Question
Given a data source such as:

```
public class Data
{
    public List<User> Users;
}
 
public class User
{
    public string Email;
    public string FullName;
    public int Age;
}
```

We want to write an engine that would accept a SQL string and output the results of the query.  
Queries are in the following format: `from <Source> where <Expression> select <Field>`  
Where Source is one of the properties on the data source, the where expression is a potentially compound predicate that can include equality, range comparisons, etc.  
You do not need to support queries that are more complex than the format above.   


##### Sample queries:
-	from Users where FullName = "John Doe" AND Age > 30 select Email
-	from Users where Email = "selected.databases@ravendb.net" select FullName, Email
-	from Users where Email = 'jobs@ravendb.net' or Email = 'jobs@hibernatingrhinos.com' select FullName, Email
- from Users where Email = 'jobs@ravendb.net' or Age >= 18 and Age <= 99 select FullName, Email
-	from Users where (FullName = 'foo' or FullName = 'bar') and Age < 99 select FullName, Email
 
 
You can output the results of the query to the console or return them as a list from the query engine.
