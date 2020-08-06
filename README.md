<p align="center">
  <img style="float: right;" src="https://www.clipartkey.com/mpngs/m/20-203198_handshake-clipart-hand-shake-clip-art-png.png" width=400px; height=300px>
</p>

# DeclarativeContracts    ![Build](https://github.com/ArturLavrov/DeclarativeContracts/workflows/Build/badge.svg?branch=master) [![codecov](https://codecov.io/gh/ArturLavrov/DeclarativeContracts/branch/master/graph/badge.svg?token=LD45D8GXZB)](https://codecov.io/gh/ArturLavrov/DeclarativeContracts)


<b><i><h3>Lightweight library that enforce design by contract approach in clean and declarative manner</h3></i></b>


Design by contract is not a brand new, but really powerful technique that could make software reliable and safe from bugs. If you not familiar with this idea, please check [this link.](https://www.eiffel.org/doc/solutions/Design_by_Contract_and_Assertions)

## Precondition
Precondition helps to verify that client's of your public API does not violate declared  contract that you declared.
For this purpose use class `Require`

For example:

    public void SaveClientInfo(Client client)
    {
        Require.That(client, (client) => clinet != null);

        //method body implementation code

    }
or

The following lines is a little bit clumsy and hard to read. For solving this issue DeclarativeContracts contains a lot of out of the box functions that incapsulate required functionality

For instance, above checks could be done in the following manner:

    public void CheckClientInfo(Client client)
    {
        Require.That(clinet, Is.NotNull);

        //TODO: method code

    }
Moreover `Is` and `Has` classes provide a lot of other useful methods such as: 

Is.Null

Is.NotNull

Is.Default

Is.NotDefault

Is.NotOrEmptyString

Is.Positive

Is.Negative

Is.False

Is.True

Is.Odd

Is.Even

## Postcondition

Postcondition helps to be sure that you public method always returns expected result and client could be sure that call if thees methods is always save 

To perform postcondition check use class: `Ensure.`

 For example:

    public VerificationResult VerifyClient(Client client)
    {
        Require.That(clinet, Is.NotNull);

        var verificationResult = _verificationService.VerifyClient(client);

        Ensure.That(verificationResult, Is.NotNull);
    }


As you could see, this class could be easily combine with build your custom delegates or build in functions.


## Q&A
