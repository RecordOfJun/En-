package utility;

public class UserInputProcessing {
	public String splitCommand(String line) {//공백문자열을 기준으로 명령어 쪼개기
		String[] command=line.trim().split("[\\s]+");
		return command[0];
	}
	public int extractCommand(String line) {
		String command=line.trim().toLowerCase();
		int branchCase=0;
		int checkingIndex=0;
		if(command.startsWith("cd")) {
			branchCase=1;
			checkingIndex=2;
		}
		else if(command.startsWith("dir")) {
			branchCase=2;
			checkingIndex=3;
		}
		else if(command.startsWith("copy")) {
			branchCase=3;
			checkingIndex=4;
		}
		else if(command.startsWith("help")) {
			branchCase=4;
			checkingIndex=4;
		}
		else if(command.startsWith("cls")) {
			branchCase=5;
			checkingIndex=4;
		}
		else if(command.startsWith("move")) {
			checkingIndex=4;
			branchCase=6;
		}
		else if(command.startsWith("exit")) {
			branchCase=7;
			checkingIndex=4;	
		}
		if(command.length()>checkingIndex&&command.substring(checkingIndex,checkingIndex+1).matches("[(가-힣)|(0-9)|(a-z)]"))
			branchCase=0;
		return branchCase;
	}
}
