package utility;

public class UserInputProcessing {
	public static UserInputProcessing instance;
	public static UserInputProcessing getInstance() {
		if(instance==null)
			instance=new UserInputProcessing();
		return instance;
	}
	public String splitCommand(String line) {//공백문자열을 기준으로 명령어 쪼개기
		String[] command=line.trim().split("[\\s]+");
		return command[0];
	}
}
