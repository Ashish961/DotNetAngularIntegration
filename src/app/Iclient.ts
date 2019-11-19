export class IClientsDetails{
    Id :number;
    FirstName:string;
    LastName:string;
    Dob:string;
    Address:ClientAddress[];

}
export class ClientAddress{
    Address:string;
} 