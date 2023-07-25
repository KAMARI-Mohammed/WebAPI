using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class AppUser:IdentityUser{

    public AppUser(){
        Message= new HashSet<Messages>();
    }

    public virtual ICollection<Messages>Message {get; set ;}

}