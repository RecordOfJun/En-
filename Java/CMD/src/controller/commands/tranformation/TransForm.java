package controller.commands.tranformation;

import java.io.File;
import java.util.Scanner;

import controller.CommandExcution;
import controller.commands.Command;
import model.DirectoryData;
import utility.Constant;
import view.CommandResult;

public class TransForm extends Command implements CommandExcution {
	public TransForm(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
	}
	public void excuteCommand(String command) {
		synchronizeFile();
		setBranchByCommandLength(command);
		commandResult.addLine();
	}
	private void setBranchByCommandLength(String command) {//커맨드에 찍힌 파일 개수에 따라 분기
		String[] filePaths=command.trim().split(Constant.BLANK);
		switch(filePaths.length) {
			case Constant.LENGTHONE:
				handleOnePath(filePaths[Constant.LEFTFILE]);
				break;
			case Constant.LENGTHTWO:
				handleTwoPath(filePaths[Constant.LEFTFILE], filePaths[Constant.RIGHTFILE]);
				break;
			default:
				handleMorePath(filePaths[Constant.LEFTFILE]);
				break;
		}

	}
	private void handleOnePath(String filePath) {
		if(filePath.equals(Constant.EMPTY))//아무것도 없을 때
			commandResult.announceWrongCommand();
		else {
			handleTwoPath(filePath,Constant.EMPTY);
		}
	}
	private void handleTwoPath(String leftPath,String rightPath) {//파일 두개일때
		movePath(leftPath);
		path=new File(getPath(path));
		if(path.exists()) {
			transferFile(rightPath);
		}
		else {
			commandResult.announceFileFindFailed();
		}
	}
	private void handleMorePath(String leftPath) {//파일 세개 이상일 때
		movePath(leftPath);
		path=new File(getPath(path));
		if(path.exists()) {
			commandResult.announceWrongCommand();
		}
		else {
			commandResult.announceFileFindFailed();
		}
	}
	protected int askCover(String rightFileName) {//덮어쓰기 질문
		Scanner userInput=new Scanner(System.in);
		boolean isAnswered=false;
		int answerResult=0;
		while(!isAnswered) {
			commandResult.askCover(rightFileName);
			String answer=userInput.nextLine();
			switch(answer.toLowerCase().charAt(0)) {
				case Constant.STARTWITHY:
					isAnswered=true;
					answerResult=Constant.ANSWERYES;
					break;
				case Constant.STARTWITHN:
					isAnswered=true;
					answerResult=Constant.ANSWERNO;
					break;
				case Constant.STARTWITHA:
					isAnswered=true;
					answerResult=Constant.ANSWERALL;
					break;
				default:
					break;
			}
		}
		return answerResult;
	}
	protected void transferFile(String rightPath) {
		
	}
	protected void announceMoveComplete(File leftFile,int count) {//파일 이동 완료구문
		if(leftFile.isDirectory())
			commandResult.announceDirectoryMoveComplete(count);
		else
			commandResult.announceFileMoveComplete(count);
	}
}
