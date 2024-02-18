package tn.esprit.entites;

import javax.xml.bind.annotation.XmlRootElement;

import com.sun.xml.internal.txw2.annotation.XmlAttribute;
import com.sun.xml.internal.txw2.annotation.XmlElement;

@XmlRootElement
public class RendezVous {
	int id;
	private String date;
	private String heure;
	private Logement logement;
	private String numTel;
	
	
	public RendezVous() {
		super();
		// TODO Auto-generated constructor stub
	}
	
	
	public RendezVous(int id, String date, String heure, Logement logement, String numTel) {
		super();
		this.id=id;
		this.date = date;
		this.heure = heure;
		this.logement = logement;
		this.numTel = numTel;
	}

	@XmlAttribute
	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	@XmlElement
	public String getDate() {
		return date;
	}


	public void setDate(String date) {
		this.date = date;
	}

	@XmlElement
	public String getHeure() {
		return heure;
	}


	public void setHeure(String heure) {
		this.heure = heure;
	}

	@XmlElement
	public Logement getLogement() {
		return logement;
	}
	public void setLogement(Logement logement) {
		this.logement = logement;
	}
	
	@XmlElement
	public String getNumTel() {
		return numTel;
	}
	public void setNumTel(String numTel) {
		this.numTel = numTel;
	}


	@Override
	public String toString() {
		return "RendezVous [id=" + id + ", date=" + date + ", heure=" + heure + ", logement=" + logement + ", numTel="
				+ numTel + "]";
	}


	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + id;
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
		RendezVous other = (RendezVous) obj;
		if (id != other.id)
			return false;
		return true;
	}


	

}
