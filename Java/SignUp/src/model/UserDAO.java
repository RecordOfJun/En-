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
	
	private void connectDB() {
		try {
			Class.forName("com.mysql.jdbc.Driver");
			connection=DriverManager.getConnection("jdbc:mysql://localhost:3306/signup","root","0000");
		}
		catch(Exception e) {
			System.out.print("연결실패");
		}
	}
	public String insertRecord(String id,String pw, String name, String personal,String phone,String adress) {
		try {
			connectDB();
			Statement statement=connection.createStatement();
			
			query=String.format("\nInsert INTO user VALUES('%s','%s','%s','%s','%s','%s');", id,pw,name,personal,phone,adress);
			statement.executeUpdate(query);
			connection.close();
			return "연결성공";
		}
		catch(Exception e) {
			return "연결실패";
		}
	}
	
	public ArrayList<String> SelectRecord(String id) {
		ArrayList<String> list=new ArrayList<String>();
		try {
			connectDB();
			Statement statement=connection.createStatement();
			query="SELECT * FROM user WHERE ID="+id+";";
			ResultSet result=statement.executeQuery(query);
			while(result.next()) {
				list.add(result.getString("ID"));
				list.add(result.getString("PW"));
				list.add(result.getString("Name"));
				list.add(result.getString("Personal"));
				list.add(result.getString("Phone"));
				list.add(result.getString("Adress"));
			}
			connection.close();
		}
		catch(Exception e) {
			System.out.print("연결실패");
		}
		return list;
	}
	
	public String CheckID(String id,String pw) {
		try {
			connectDB();
			Statement statement=connection.createStatement();
			query="SELECT ID FROM user WHERE ID="+id+" and PW="+pw+";";
			ResultSet result=statement.executeQuery(query);
			String foundID=result.getString("ID");
			connection.close();
			return foundID;
		}
		catch(Exception e) {
			return "연결실패";
		}
	}
}
