package com.esprit.ressources;

import java.util.ArrayList;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import com.esprit.busniss.LogementBusiness;
import com.esprit.busniss.RendezVousBusiness;
import com.esprit.entities.RendezVous;


@Path("rendezvous")
public class RendezVousResources 
{	
	public static RendezVousBusiness RB=new RendezVousBusiness();
	public static LogementBusiness logementMetier=new LogementBusiness();
	RendezVous r= new RendezVous(1, "31-10-2015","15:30", logementMetier.getLogementsByReference(4), "55214078");
	
	@POST
	@Consumes(MediaType.APPLICATION_JSON)
	public Response addRendezVous(RendezVous rend)
	{
		RB.addRendezVous(rend);	
		return Response.status(Status.CREATED).entity("add succes").build();
	}
	

	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public Response findbyRef(@QueryParam(value ="refLogement") Integer ref)
	//QueryParam => <path>?refLogement=<valeur>
	{
		if(ref != null)
		{
	if(RB.getListeRendezVousByLogementReference(ref)!=null) 
	{
		List<RendezVous> list=new ArrayList<RendezVous>();
		list=RB.getListeRendezVousByLogementReference(ref);
		return Response.status(Status.OK).entity(list).build();
	}
	else 
	{
		return Response.status(Status.NOT_FOUND).entity("impossible de trouver").build();
	}
		}
		return Response.status(Status.OK).entity(RB.getListeRendezVous()).build();
	}
	
	
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("{refLogement}")
	public Response findbyRef1(@PathParam(value="refLogement")int ref)
	//PathParam => <path>/<valeur>
	{
		if(RB.getListeRendezVousByLogementReference(ref)!=null)
		{
			List<RendezVous> list=new ArrayList<RendezVous>();
			list=RB.getListeRendezVousByLogementReference(ref);
			return Response.status(Status.OK).entity(list).build();
		}
		return Response.status(Status.NOT_FOUND).entity("impossible de trouver").build();
	}
	
	@PUT
	@Consumes(MediaType.APPLICATION_JSON)
	@Path("{id}")
	public Response update(@PathParam(value="id")int id,RendezVous r)
	{
		if(RB.getListeRendezVousByLogementReference(id)!=null)
		{
		
				RB.deleteRendezVous(id);
				RB.addRendezVous(r);
	return Response.status(Status.OK).entity("Rendez-vous a ete modifie").build();
		}
		return Response.status(Status.NOT_MODIFIED).entity("impossible de modifier").build();
	}
	
	
	@DELETE
	@Consumes(MediaType.APPLICATION_JSON)
	@Path("{id}")
	public Response update(@PathParam(value="id")int id)
	{
		if(RB.getListeRendezVousByLogementReference(id)!=null)
		{
		
				
				RB.deleteRendezVous(id);
	return Response.status(Status.GONE).entity("Rendez-vous a ete supprimer").build();
		}
		return Response.status(Status.NOT_FOUND).entity("impossible de supprimer").build();
	}
	
	
	//Partie Interoperabilite
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	@Path("/interoperabilite/{id}")
	public Response getDetails(@PathParam(value="id")int id) 
	{
		RendezVous r = RB.getRendezVousById(id);
		return Response.status(Status.OK).entity(r).header("Access-Control-Allow-Origin", "*").build();
	}
}
