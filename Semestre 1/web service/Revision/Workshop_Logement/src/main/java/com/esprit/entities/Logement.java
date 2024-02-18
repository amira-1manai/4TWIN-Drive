package com.esprit.entities;

import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class Logement {
	private int reference;
	private String adresse;
	private String delegation;
	private String gouvernorat;
	private Type type;
	private String description;
	private float prix;
	
	public enum Type {Studio, Appartement, Villa, EtageVilla} ;

	
	
	public Logement() {
		super();
		// TODO Auto-generated constructor stub
	}
	


	public Logement(int reference, String adresse, String deleguation, String gouvernorat, Type type, String description, float prix) {
		super();
		this.reference = reference;
		this.adresse = adresse;
		this.delegation = deleguation;
		this.gouvernorat = gouvernorat;
		this.type=type;
		this.description = description;
		this.prix = prix;
	}



	@XmlAttribute
	public int getReference() {
		return reference;
	}



	public void setReference(int reference) {
		this.reference = reference;
	}


@XmlElement
	public String getAdresse() {
		return adresse;
	}
	public void setAdresse(String adresse) {
		this.adresse = adresse;
	}
	@XmlElement
	public String getDeleguation() {
		return delegation;
	}
	public void setDeleguation(String deleguation) {
		this.delegation = deleguation;
	}
	@XmlElement
	public String getGouvernorat() {
		return gouvernorat;
	}
	public void setGouvernorat(String gouvernorat) {
		this.gouvernorat = gouvernorat;
	}
	@XmlElement
	public Type getType() {
		return type;
	}



	public void setType(Type type) {
		this.type = type;
	}


	@XmlElement
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	@XmlElement
	public float getPrix() {
		return prix;
	}
	public void setPrix(float prix) {
		this.prix = prix;
	}



	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + reference;
		return result;
	}



	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Logement other = (Logement) obj;
		if (reference != other.reference)
			return false;
		return true;
	}



	@Override
	public String toString() {
		return "Logement [reference=" + reference + ", adresse=" + adresse + ", delegation=" + delegation
				+ ", gouvernorat=" + gouvernorat + ", type=" + type + ", description=" + description + ", prix=" + prix
				+ "]";
	}
	
	
	

}
