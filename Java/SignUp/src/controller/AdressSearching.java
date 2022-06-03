package controller;
import java.io.BufferedReader;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.net.HttpURLConnection;
import java.io.InputStreamReader;
import org.json.simple.parser.*;
import org.json.simple.*;
import javax.swing.*;
import javax.imageio.ImageIO;
import java.awt.Image;

public class AdressSearching {
	public ArrayList<String> getAdresses(String query){
		ArrayList<String> adresses=new ArrayList<String>();
		String[] lines=getLines(query).split(",");
		for(int count=0;count<lines.length;count++) {
			if(lines[count].contains("roadAddrPart1"))
				adresses.add(lines[count].replace("roadAddrPart1", "").replace(":", "").replace("\"",""));
			if(lines[count].contains("jibunAddr"))
				adresses.add(lines[count].replace("jibunAddr", "").replace(":", "").replace("\"",""));
		}
		return adresses;
	}
	public String getLines(String query) {
		String result;
		try {
			URL url=new URL("https://www.juso.go.kr/addrlink/addrLinkApi.do?currentPage="+1
					+"&countPerPage=99&keyword="+URLEncoder.encode(query,"UTF-8")
					+"&confmKey=devU01TX0FVVEgyMDIyMDYwNDA0MTAyMjExMjY0ODc=&resultType=json");
			BufferedReader br=new BufferedReader(new InputStreamReader(url.openStream(),"UTF-8"));
			StringBuffer sb=new StringBuffer();
			String temp=null;
			while(true) {
				temp=br.readLine();
				if(temp==null)break;
				sb.append(temp);
			}
			result=sb.toString();
		}
		catch(Exception e) {
			result="결과없음";
		}
		return result;
	}
}
