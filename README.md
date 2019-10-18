
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

All of the above slots takes an expression, or valus, as its main input, and will return a friendly error message after having been
invoked as their main value if validation failed.
