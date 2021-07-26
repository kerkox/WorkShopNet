# WorkShopNet
## WrokShop .Net Training

This application validate an Identifier using the bellow rules
- An identifier must not null or empty
- An identifier must have at least 5 characters and max 32 characters
- An identifier must start with an uppercase letter

The Validation for the entries use different validation methods
- Using Regular Expressions
- Using normal IF statements
- Throw exceptions in case any rule is not followed

The application shows the errors list for each broken rule and,
If the identifier is correct, returns an empty list.

The application must execute 1'000.000 iterations for each method (RegEx, If, Exceptions)
and for each iteration the task must execute :
- A call with an identifier without problem
- A call with an identifier that does not meet the minimum length
- A call with a string that does not meet the maximum length
- A call with a string that does not meet the capital letter rule.

Each execution must measure total execution time and the
average and total processor and memory consumption by each method

Show execution times and memory / processor information for each method in console.
{"mode":"full","isActive":false}