package utility;

public class UserInputProcessing {
	public String splitCommand(String line) {//공백문자열을 기준으로 명령어 쪼개기
		String[] command=line.trim().split(Constant.BLANK);
		return command[0];
	}
	public int extractCommand(String line) {//명령어 추출 함수
		String command=line.trim().toLowerCase();
		int branchCase=0;
		int checkingIndex=0;
		//앞글자가 무엇으로 시작하는지 판단
		if(command.startsWith("cd")) {
			branchCase=Constant.CD;
			checkingIndex=Constant.CDLENGTH;
		}
		else if(command.startsWith("dir")) {
			branchCase=Constant.DIR;
			checkingIndex=Constant.DIRLENGTH;
		}
		else if(command.startsWith("copy")) {
			branchCase=Constant.COPY;
			checkingIndex=Constant.COPYLENGTH;
		}
		else if(command.startsWith("help")) {
			branchCase=Constant.HELP;
			checkingIndex=Constant.HELPLENGTH;
		}
		else if(command.startsWith("cls")) {
			branchCase=Constant.CLS;
			checkingIndex=Constant.CLSLENGTH;
		}
		else if(command.startsWith("move")) {
			checkingIndex=Constant.MOVELENGTH;
			branchCase=Constant.MOVE;
		}
		else if(command.startsWith("exit")) {
			branchCase=Constant.EXIT;
			checkingIndex=Constant.EXITLENGTH;	
		}
		//
		if(command.length()>checkingIndex&&command.substring(checkingIndex,checkingIndex+1).matches("[(가-힣)|(0-9)|(a-z)]"))
			branchCase=Constant.NONECOMMAND;
		return branchCase;
	}
}
