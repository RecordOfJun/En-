package utility;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class OSLink {
	public String execCmd(String cmd) {//현재 컴퓨터의 OS정보 가져오는 함수
	    try {
	        Process process = Runtime.getRuntime().exec("cmd /c " + cmd);
	        BufferedReader reader = new BufferedReader(
	                new InputStreamReader(process.getInputStream(),"MS949"));
	        String line = null;
	        StringBuffer sb = new StringBuffer();
	        int count=0;
	        while ((line = reader.readLine()) != null&&count<2) {
	            sb.append(line);
	            sb.append("\n");
	            count++;
	        }
	        return sb.toString().trim();
	    } catch (Exception e) {
	        e.printStackTrace();
	    }
	    return null;
	}
}
