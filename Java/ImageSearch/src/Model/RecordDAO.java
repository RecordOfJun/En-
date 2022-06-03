package Model;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;
import java.util.ArrayList;
import java.time.LocalDateTime;
import Utility.Constant;

import java.sql.ResultSet;

public class RecordDAO {
	private Connection connection;
	private String query;
	private void ConnectDB() {
		try {
			Class.forName("com.mysql.cj.jdbc.Driver");
			connection=DriverManager.getConnection(Constant.URL,Constant.USERNAME,Constant.PASSWORD);
		}
		catch(Exception e) {
			System.out.print("연결실패");
		}
	}
	
	public ArrayList<String> SelectRecord() {
		ArrayList<String> list=new ArrayList<String>();
		try {
			ConnectDB();
			Statement statement=connection.createStatement();
			query="SELECT InsertTime,Record FROM searchrecord ORDER BY InsertTime DESC;";
			ResultSet result=statement.executeQuery(query);
			int count=0;
			while(result.next()) {
				list.add(result.getString("InsertTime"));
				list.add(result.getString("Record"));
			}
			connection.close();
		}
		catch(Exception e) {
			System.out.print("연결실패");
		}
		return list;
	}
	public void InsertRecord(String record) {
		try {
			ConnectDB();
			Statement statement=connection.createStatement();
			LocalDateTime now=LocalDateTime.now();
			query="Delete FROM searchrecord WHERE Record="+record;
			query=String.format("\nInsert INTO searchrecord VALUES('%s','%s');", record,now);
			statement.executeUpdate(query);
			connection.close();
		}
		catch(Exception e) {
			System.out.print("연결실패");
		}
	}
	public void DeleteRecord() {
		try {
			ConnectDB();
			Statement statement=connection.createStatement();
			query="Delete FROM searchrecord;";
			statement.executeUpdate(query);
			connection.close();
		}
		catch(Exception e) {
			System.out.print("연결실패");
		}
	}
}
