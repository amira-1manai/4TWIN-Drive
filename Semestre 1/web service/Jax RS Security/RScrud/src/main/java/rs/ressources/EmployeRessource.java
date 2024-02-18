package rs.ressources;

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
import javax.ws.rs.core.GenericEntity;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import io.swagger.annotations.ApiResponse;
import io.swagger.annotations.ApiResponses;
import rs.entities.Employe;




@Path("employes")
@Api
public class EmployeRessource {
	
	public static  List<Employe> employes=new ArrayList<Employe>();
	 public EmployeRessource() {
		// TODO Auto-generated constructor stub
		EmployeRessource.employes.add(new Employe(12,"ffff","ffff"));	
		
	
	}
	@GET
	@Produces(MediaType.TEXT_PLAIN)
	@ApiOperation(value = "Fetch all EMPLOYEES")
	  @ApiResponses({
	    @ApiResponse(code=200, message="Success")
	  })
	public String sayHello() {
		return "Hello from JAX-RS";
	}
	
	
	
	@POST	
	@Consumes(MediaType.APPLICATION_XML)
	@ApiOperation(value = "Add Employe")
	  @ApiResponses({
	    @ApiResponse(code=200, message="Success")
	  })
	
	public  Response    ajouterEmploye(Employe employe) {
		if(employes.add(employe))
		{
			return Response.status(Status.CREATED).entity("add success").build();

		}
		else
			return Response.status(Status.NOT_FOUND).entity("Not Add").build();	
		
	}
	
	@GET
	@Path("add")
	@ApiOperation(value = "Get All Employes",produces = MediaType.APPLICATION_XML)
	  @ApiResponses({
	    @ApiResponse(code=200, message="Success")
	  })
	public  Response  displayEmployeesList() {
		
		if(employes.size()!=0) {
		    GenericEntity entity = new GenericEntity<List<Employe>>(employes){};
			return Response.status(Status.FOUND).entity(entity).build();

		}
		else
			return Response.status(Status.NOT_FOUND).entity("Not fuund").build();
			
		
	}
	
	
	
	
	
	
/*	@POST
	@Consumes(MediaType.APPLICATION_XML)
	@Produces(MediaType.APPLICATION_JSON)// Par défaut
	
	public Response addEmploy(Employe e) {
		employes.add(e);
		return Response.status(Status.CREATED).entity(e).build();
	}
	*/
	
	
	
	//@Produces(MediaType.APPLICATION_JSON)
	
	
	/*public Response addInfoEmploye(Employe info){
		 if (employes.add(info)){
		
			 return Response.status(Status.CREATED).entity(info).build();
		 }
		
		 return Response.status(Status.BAD_REQUEST).build();
	}*/
	
	
	
	
	
	
/*	
	@POST
	@Consumes(MediaType.APPLICATION_XML)
	@Produces(MediaType.APPLICATION_JSON)
	public Response addInfoEmploye2(Employe info){
		 if (employes.add(info)){		
			 return Response.status(Status.CREATED).entity(info).build();
		 }
		 	
		 	return Response.status(Status.BAD_REQUEST).build();
	}*/
	
	@GET
	@Produces(MediaType.APPLICATION_XML)
	@Path("/{ciin}")
	@ApiOperation(value = "Get Employes by",produces = MediaType.APPLICATION_XML)
	  @ApiResponses({
	    @ApiResponse(code=200, message="Success")
	  })
	public Response getEmploye(@PathParam("ciin") int cin) {
		for (Employe info:employes) {
	       if(info.getCin()==cin) {
	    	   return  Response.status(Status.FOUND)
						.entity(info)
						.build(); 
	    	
	       }
		}
	       		
			return  Response.status(Status.NOT_FOUND).build();
		
		
	}
	
	//@Secured
	/*@GET
	@Produces(MediaType.APPLICATION_JSON)
	public Response getAll(){		
		 
		  if(employes.size() != 0) {
				return Response.status(Status.OK).entity(employes).build(); 
			}
			return Response.status(Status.NOT_FOUND).build();	
	}
	
	*/	
	@PUT
	@Consumes(MediaType.APPLICATION_XML)
	public Response updateEmploye(Employe e) {
		int index= this.getIndexByCin(e.getCin());
		if (index!=-1) {
			employes.set(index, e);
			return Response.status(Status.OK).entity("update successful").build();
			
		}
		return Response.status(Status.NOT_FOUND).entity("update unsuccessful").build();
	
	}
	public int getIndexByCin(int cin) {
		for(Employe emp: employes) {
			if (emp.getCin()==cin)
				return employes.indexOf(emp);
		}
		return -1;
	}

	
	@DELETE
	@Path("{cin}")
	public boolean deleteEmpl(@PathParam("cin") int cin){
		int index= getIndexByCin(cin);
		
		if (index!=-1) {
			employes.remove(index);
			return true;
		}else 
			return false;
			
    }
		
		
	
		
}
