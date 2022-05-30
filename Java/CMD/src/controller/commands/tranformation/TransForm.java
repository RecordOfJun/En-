package controller.commands.tranformation;

import java.io.File;
import java.util.Scanner;

import controller.commandExcution;
import controller.commands.Command;
import model.DirectoryData;
import utility.Constant;
import view.CommandResult;

public class TransForm extends Command implements commandExcution {
	public TransForm(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
		// TODO Auto-generated constructor stub
	}
	public void excuteCommand(String command) {
		// TODO Auto-generated method stub
		synchronizeFile();
		setBranchByCommandLength(command);
	}
	private void setBranchByCommandLength(String command) {
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
		if(filePath.equals(Constant.EMPTY))
			commandResult.announceWrongCommand();
		else {
			handleTwoPath(filePath,Constant.EMPTY);
		}
	}
	private void handleTwoPath(String leftPath,String rightPath) {
		movePath(leftPath);
		path=new File(getPath(path));
		if(path.exists()) {
			transferFile(rightPath);
		}
		else {
			commandResult.announceFileFindFailed();
		}
	}
	private void handleMorePath(String leftPath) {
		movePath(leftPath);
		path=new File(getPath(path));
		if(path.exists()) {
			commandResult.announceWrongCommand();
		}
		else {
			commandResult.announceFileFindFailed();
		}
	}
	protected int askCover(String rightFileName) {
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
	protected void announceMoveComplete(File leftFile,int count) {
		if(leftFile.isDirectory())
			commandResult.announceDirectoryMoveComplete(count);
		else
			commandResult.announceFileMoveComplete(count);
	}
}
