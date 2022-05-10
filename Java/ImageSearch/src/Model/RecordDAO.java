package Model;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

import Utility.Constant;

import java.sql.ResultSet;

public class RecordDAO {
	private Connection connection;
	private String query;
	private void ConnectDB() {
		try {
			Class.forName("com.mysql.jdbc.Driver");
			//connection=DriverManager.getConnection(Constant.URL,Constant.USERNAME,Constant.PASSWORD);
		}
		catch(Exception e) {
			
		}
	}
	
	public void SelectRecord() {
		try {
			ConnectDB();
			Statement statement=connection.createStatement();
			query="SELECT Record FROM SearchRecord";
			ResultSet result=statement.executeQuery(query);
			while(result.next()) {
				
			}
		}
		catch(Exception e) {
			
		}
	}
	public void InsertRecord(String record) {
		
	}
	public void DeleteRecord() {
		
	}
}
