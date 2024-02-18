package tn.esprit.resources;

import javax.ws.rs.Consumes;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response.Status;
import javax.ws.rs.core.Response;

import tn.esprit.business.LogementBusiness;
import tn.esprit.business.RendezVousBusiness;
import tn.esprit.entites.RendezVous;

@Path("rendezvous")
public class RendezVousResources 
{
	public static RendezVousBusiness RB= new RendezVousBusiness();
	public static LogementBusiness LogementMetier=new LogementBusiness();
	RendezVous r= new RendezVous(1, "31-10-2015", "15:30", LogementMetier.getLogementsByReference(4), "55214078");
	
	@POST
	@Consumes(MediaType.APPLICATION_JSON)
	public Response addRendezVous(RendezVous rend)
	{
		RB.addRendezVous(rend);
		return Response.status(Status.CREATED).entity("add succes").build();	
	}
	
	
}
