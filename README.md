
# Magic Lambda Validators

[![Build status](https://travis-ci.org/polterguy/magic.lambda.auth.svg?master)](https://travis-ci.org/polterguy/magic.lambda.auth)

This project contains input validators for Magic. More specifically it contains the following slots.

* __[validators.date]__ - Verifies that some date input is between __[min]__ and __[max]__ value.
* __[validators.email]__ - Verifies that some input is a legal email address.
* __[validators.enum]__ - Verifies that some input is one of a set of predefined legal values, found as values of children.
* __[validators.integer]__ - Verifies that som einteger input (long, int, etc) is between some specified __[min]__ and __[max]__ range.
* __[validators.mandatory]__ - Verifies that some input valus is given (_at all_).
* __[validators.regex]__ - Verifies that some input is matching some given __[regex]__ pattern.
* __[validators.string]__ - Verifies that some string input is between __[min]__ and __[max]__ length.
* __[validators.url]__ - Verifies that some string input is a legal URL, either HTTP or HTTPS type of scheme.

All of the above slots takes an expression, or valus, as its main input, and will throw exceptions if their input expression's
value, or its value, does not follow the rules specified by the validator. This makes them perfect fits for _"intercepting"_ the
input specified to an HTTP REST endpoint, to verify the input data conforms to some sort of predefined validator.

## Usage

```
.foo
   number:int:11

/*
 * This will throw an exception, since the expression's value is outside of the bounds
 * of the **[min]**/**[max]** range for the validator declaration.
 */
validators.integer:x:@.foo/*/number
   min:int:5
   max:int:10
```

Most validators requires some sort of argument(s), such as you can see above in the integer validator - However, some of
these validators are without arguments, such as the email validator, that simply verifies the input is a valid email address.
To use the **[validators.regex]** validator, you should probably [learn regular expression](https://medium.com/factory-mind/regex-tutorial-a-simple-cheatsheet-by-examples-649dc1c3f285).
However, this is beyond the scope of this article.

## License

Although most of Magic's source code is Open Source, you will need a license key to use it.
You can [obtain a license key here](https://servergardens.com/buy/).
Notice, 7 days after you put Magic into production, it will stop working, unless you have a valid
license for it.

* [Get licensed](https://servergardens.com/buy/)
