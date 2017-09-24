# Bud recruitment test

## Approach used
I've used a [feature slices approach](https://vimeo.com/131633177) I read about recently, but haven't really had the chance to use along with making use of [MediatR](https://github.com/jbogard/MediatR) to implement a CQRS approach.

The controllers are designed to be thin, with MediatR finding the correct handler to process the query and respond with a view model.

Unfortunately I didn't have enough time to setup a depedency injection framework, which in turn means that MediaR isn't actually being used. However I left in commented out code, to show how it would have simplified things.

There are also round rough edges, for instance the `WorldBankDataService` doesn't feature any exception handling. So if it doesn't get a valid response, it won't deal with it gracefully.

### Tests
I've written a few basic tests, just to show the use of Mock with verifications and mocks.



