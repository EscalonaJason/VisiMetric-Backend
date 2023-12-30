// See https://aka.ms/new-console-template for more information

using Domain.Repository;
using Model;

User u = new User();
u.Password = "!Krems";
u.Title = "Dr.";
u.FirstName = "Jakob";
u.LastName = "Vogl";

VMContext context = new VMContext();
UserRepository urepo = new UserRepository(context);
urepo.Add(u);

Wound w = new Wound();
w.Description = "Wound on Arm";
w.Id = "ölkjfdsa";
w.UserId = urepo.GetIdByName("Jakob", "Vogl");

WoundRepository wrepo = new WoundRepository(context);
wrepo.Add(w);