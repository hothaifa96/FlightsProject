namespace Flights
{
    internal interface IAdminstratorDAO:IBasicDB<Adminstrator>
    {
        
        void ChangePAssword(long id,string oldpassword,string newpassword);

    }
}