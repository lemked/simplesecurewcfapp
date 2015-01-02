using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

public class CredentialsValidator : UserNamePasswordValidator
{
    public override void Validate(string strUserName, string strPassword)
    {
        if (strUserName == null || strPassword == null)
        {
            throw new ArgumentNullException();
        }

        if (strUserName != "myUser" || strPassword != "myPassword")
        {
            throw new SecurityTokenException("Unknown Username or Password");
        }
    }
}