# MSCoders.Meetup.GraphQLNet
MSCoders.Meetup.GraphQLNet

## Database connection string
Set connection string in class [ConfigDB](/MSCoders.Meetup.GraphQLNet/Meetup.GraphQLNet.DataAccess/ConfigDB.cs)

```csharp
public class ConfigDB
    {
        private const string ConnectionString
            = @"Server=(localdb)\mssqllocaldb;Database=GraphQLNet.DemoDB;Integrated Security=True;ConnectRetryCount=0";
```
