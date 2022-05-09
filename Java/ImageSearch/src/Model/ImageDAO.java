package Model;
import java.io.BufferedReader;
import java.net.URL;
import java.net.HttpURLConnection;
public class ImageDAO {
	private String searchInput;
	public ImageDAO(String searchInput) {
		this.searchInput=searchInput;
	}
	public void getImage() {
		try {
		URL url=new URL("https://dapi.kakao.com/v2/search/image");
		HttpURLConnection connection=(HttpURLConnection)url.openConnection();
		connection.setRequestMethod("GET");
		
		}
		catch(Exception e) {
			
		}
	}
}
