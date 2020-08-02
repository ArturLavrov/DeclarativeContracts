# DeclarativeContracts
Tiny library that enforce design by contract approach in clean, declarative manner
![Build](https://github.com/ArturLavrov/DeclarativeContracts/workflows/Build/badge.svg?branch=master)
[![codecov](https://codecov.io/gh/ArturLavrov/DeclarativeContracts/branch/master/graph/badge.svg?token=LD45D8GXZB)](https://codecov.io/gh/ArturLavrov/DeclarativeContracts)

Design by contracts is not brand new but really powerfull techniqe that coudl make software reliable and safe from bugs.
If you not familiar with contracts dont' wory check this link first.


Precondition.

    Precondintions helps to verify that passed parameters to a method are valid and sattisfy proclameted client's contract.
    Declarative contacts provide class: Require:

    For example:
    //TODO: code examples

    Also to make this more readble you could you out-of the box predefined set of finctions:

    //TODO:example with has and is classes

    For more details check Has and Is classes.

Postcondition
    
    Methods not only should reqire a valid parameters but also returs an expected results.
    For example

    //TODO:
    example with Ensure.That(result, Is.NotNull);


Q&A
    Is is possibel to specify custom exception insted of ContractVialiationException?
    No, but you could pass you excpetiona and it will be thrw in inner excetions of ContractViolationException.