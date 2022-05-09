package Model;
import java.io.BufferedReader;
import java.net.URL;
import java.net.URLEncoder;
import java.net.HttpURLConnection;
import java.io.InputStreamReader;
import org.json.simple.parser.*;
import org.json.simple.*;
import java.util.ArrayList;
public class ImageDAO {
	public class Documents{
		ArrayList<ImageURL> documents;
	}
	public class ImageURL{
		String image_url;
	}
	public void getImage(String searchInput) {
		try {
			System.out.println(searchInput);
			String encodedQuery=URLEncoder.encode(searchInput,"UTF-8");
			URL url=new URL("https://dapi.kakao.com/v2/search/image?query="+encodedQuery);
			HttpURLConnection connection=(HttpURLConnection)url.openConnection();
			connection.setRequestMethod("GET");
			connection.setRequestProperty("Authorization", "KakaoAK 6306c1d5aedd9c2ff98e3529fe11685e");
			connection.setDoOutput(true);
			BufferedReader bufferReader;
			StringBuilder stringBuilder=new StringBuilder();
			int responseCode = connection.getResponseCode();
	        if (responseCode == 400) {
	            System.out.println("400:: �ش� ����� ������ �� ���� (������ �� ���� ������ ��, ���������� ���� Command ���� ��ġ���� ���� ��, ���������� ������ �ʰ��Ͽ� �¿� ��)");
	        } 
	        else if (responseCode == 401) {
	            System.out.println("401:: X-Auth-Token Header�� �߸���");
	        } 
	        else if (responseCode == 500) {
	            System.out.println("500:: ���� ����, ���� �ʿ�");
	        } 
	        else { // ����
	            bufferReader = new BufferedReader(new InputStreamReader(connection.getInputStream()));
	            stringBuilder = new StringBuilder();
	            String line = "";
	            while ((line = bufferReader.readLine()) != null) {
	            	stringBuilder.append(line);
	            }   
	        }
	        JSONObject jsonObject=(JSONObject)new JSONParser().parse(stringBuilder.toString());
	        JSONArray Documents=(JSONArray)jsonObject.get("documents");
	        for(int i=0;i<Documents.size();i++) {
	        	JSONObject imageurl=(JSONObject)Documents.get(i);
	        	System.out.println(imageurl.get("image_url"));
	        	if(i==29)
	        		break;
	        }
		}
		catch(Exception e) {
			
		}
	}
}
