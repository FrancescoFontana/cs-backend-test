# Quotes importer
In order to provide market analysis tools we need to import instruments (stock, etf) quotes, to do this we typically connect to different data sources depending on the instrument. The data sources return data in different formats and sometimes this data needs to be processed before we can use it. 

We need to create a flexible engine that:
- given an instrument, it fetches the data from the appropriate data source
- depending on the data source it should apply some processing logic to clean the data. For example, when importing from MS we need to remove all the values equal to 0 or null.

## Other info
- We are interested in seeing how you apply software best practices and design patterns, the code should be easily extensible and maintainable. We value quality over quantity.
- Feel free to change any part of the code, add classes and tests
- We have created two dummy data source clients that you can use, if you wish to
