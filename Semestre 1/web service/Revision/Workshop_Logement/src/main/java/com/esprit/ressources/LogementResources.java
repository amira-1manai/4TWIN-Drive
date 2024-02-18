package com.esprit.ressources;

import java.util.ArrayList;
import java.util.List;

import javax.ws.rs.*;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import com.esprit.busniss.LogementBusiness;
import com.esprit.entities.Logement;


@Path("Logement")
public class LogementResources {

	public static LogementBusiness LB=new LogementBusiness();
	
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public Response findbygouvernat(@QueryParam(value ="reference") Integer d)
	{
		if(d != null)
		{
			if(LB.getLogementsByReference(d)!=null) {
				Logement l=new Logement();
				l=LB.getLogementsByReference(d);
				return Response.status(Status.OK).entity(l.getGouvernorat()).build();
			}
			return Response.status(Status.NOT_FOUND).entity("impossible de trouver").build();
		}
		return Response.status(Status.OK).entity(LB.getLogements()).build();
	}
	
	@GET
	@Produces(MediaType.APPLICATION_JSON)
	public Response GetAll()
	{
		if(LB.getLogements()!=null)
		{
			return Response.status(Status.OK).entity(LB.getLogements()).build();
		}
		else
			return Response.status(Status.NOT_FOUND).entity("impossible de trouver").build();	
	}
}
