package model;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.sql.ResultSet;

public class UserDAO {
	private Connection connection;
	private String query;
	LocalDateTime now=LocalDateTime.now();
	public static UserDAO instance;
	
	private UserDAO() {};
	
	public static synchronized UserDAO getInstance() {
		if(instance==null)
			instance=new UserDAO();
		return instance;
	}
	
	private void connectDB() {
		try {
			Class.forName("com.mysql.cj.jdbc.Driver");
			connection=DriverManager.getConnection("jdbc:mysql://localhost:3306/signup","root","0000");
		}
		catch(Exception e) {
			System.out.print("연결실패");
		}
	}
	public String insertUser(String id,String pw, String name, String personal,String phone,String adress,String detailAdress) {
		try {
			connectDB();
			Statement statement=connection.createStatement();
			
			query=String.format("Insert INTO user VALUES('%s','%s','%s','%s','%s','%s','%s');", id,pw,name,personal,phone,adress,detailAdress);
			statement.executeUpdate(query);
			connection.close();
			return "연결성공";
		}
		catch(Exception e) {
			return "연결실패";
		}
	}
	
	public ArrayList<String> SelectUser(String id) {
		ArrayList<String> list=new ArrayList<String>();
		try {
			connectDB();
			Statement statement=connection.createStatement();
			query="SELECT * FROM user WHERE ID='"+id+"';";
			ResultSet result=statement.executeQuery(query);
			while(result.next()) {
				list.add(result.getString("ID"));
				list.add(result.getString("PW"));
				list.add(result.getString("Name"));
				list.add(result.getString("PersonalCode"));
				list.add(result.getString("PhoneNumber"));
				list.add(result.getString("Adress"));
				list.add(result.getString("DetailAdress"));
			}
			connection.close();
		}
		catch(Exception e) {
			System.out.print("연결실패");
		}
		return list;
	}
	
	public String UpdateUser(String id,String pw, String name,String phone,String adress,String detailAdress) {
		try {
			connectDB();
			Statement statement=connection.createStatement();
			
			query=String.format("UPDATE user SET PW='%s', Name='%s', PhoneNumber='%s', Adress='%s', DetailAdress='%s' WHERE ID='%s';", pw,name,phone,adress,detailAdress,id);
			statement.executeUpdate(query);
			connection.close();
			return "연결성공";
		}
		catch(Exception e) {
			return "연결실패";
		}
	}
	
	public String CheckID(String id,String pw) {
		try {
			String foundID="";
			connectDB();
			Statement statement=connection.createStatement();
			query=String.format("SELECT ID FROM user WHERE ID='%s' and PW='%s';", id,pw);
			ResultSet result=statement.executeQuery(query);
			while(result.next())
				foundID=result.getString("ID");
			connection.close();
			return foundID;
		}
		catch(Exception e) {
			System.out.println(e.getClass().toString());
			return "연결실패";
		}
	}
	
	public String FindID(String name,String personal) {
		try {
			System.out.println(personal);
			String foundID="";
			connectDB();
			Statement statement=connection.createStatement();
			query=String.format("SELECT ID FROM user Where Name='%s' and PersonalCode='%s';", name,personal);
			ResultSet result=statement.executeQuery(query);
			while(result.next())
				foundID=result.getString("ID");
			connection.close();
			return foundID;
		}
		catch(Exception e) {
			System.out.println(e.getClass().toString());
			return "연결실패";
		}
	}
	
	public String FindPW(String name,String personal,String id) {
		try {
			String foundPW="";
			connectDB();
			Statement statement=connection.createStatement();
			query=String.format("SELECT PW FROM user Where Name='%s' and PersonalCode='%s' and Id='%s';", name,personal,id);
			ResultSet result=statement.executeQuery(query);
			while(result.next())
				foundPW=result.getString("PW");
			connection.close();
			return foundPW;
		}
		catch(Exception e) {
			System.out.println(e.getClass().toString());
			return "연결실패";
		}
	}
	
	public boolean isExistedID(String id) {
		try {
			String foundID="";
			connectDB();
			Statement statement=connection.createStatement();
			query="SELECT ID FROM user WHERE ID='"+id+"';";
			ResultSet result=statement.executeQuery(query);
			while(result.next())
				foundID=result.getString("ID");
			connection.close();
			if(foundID.length()!=0)
				return true;
			return false;
		}
		catch(Exception e) {
			System.out.println(e.getClass().toString());
			return false;
		}
	}
	
	public boolean isExistedPersonal(String personal) {
		try {
			String foundPersonal="";
			connectDB();
			Statement statement=connection.createStatement();
			query="SELECT PersonalCode FROM user WHERE PersonalCode='"+personal+"';";
			ResultSet result=statement.executeQuery(query);
			while(result.next())
				foundPersonal=result.getString("PersonalCode");
			connection.close();
			if(foundPersonal.length()!=0)
				return true;
			return false;
		}
		catch(Exception e) {
			System.out.println(e.getClass().toString());
			return false;
		}
	}
	
	public void deleteUser(String id) {
		try {
			System.out.println(id);
			connectDB();
			Statement statement=connection.createStatement();
			query="DELETE FROM user WHERE ID='"+id+"';";
			statement.executeUpdate(query);
			connection.close();
		}
		catch(Exception e) {
			System.out.println(e.getClass().toString());
		}
	}
}
