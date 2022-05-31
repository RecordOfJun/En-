package controller.commands.tranformation;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import model.DirectoryData;
import utility.Constant;
import view.CommandResult;

public class MOVE extends TransForm{

	public MOVE(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
	}
	protected void transferFile(String rightPath) {
		File leftFile=new File(getPath(path));
		synchronizeFile();
		movePath(rightPath);
		File rightFile=new File(getPath(path));
		moveFile(leftFile,rightFile);
		
	}
	private void moveFile(File leftFile,File rightFile) {
		if(!rightFile.exists())
			tryMove(leftFile,rightFile);
		else {
			if(rightFile.isFile()) {
				int answer=askCover(getPath(rightFile));
				if(answer==Constant.ANSWERYES||answer==Constant.ANSWERALL) {
					tryMove(leftFile,rightFile);
				}
				else
					announceMoveComplete(leftFile, 0);
			}
			else if(rightFile.isDirectory()) {
				moveToDirectory(leftFile, rightFile);
			}
		}
	}
	private void moveToDirectory(File leftFile,File rightFile) {
		rightFile=new File(rightFile.getPath()+Constant.BACKSLASH+leftFile.getName());
		if(rightFile.exists()) {
			int answer=askCover(getPath(rightFile));
			if(rightFile.isDirectory()) {
				if(answer==Constant.ANSWERYES||answer==Constant.ANSWERALL) {
					commandResult.excessDenied();
				}
				else
					announceMoveComplete(leftFile, 1);
			}
			else if(rightFile.isFile()) {
				if(answer==Constant.ANSWERYES||answer==Constant.ANSWERALL) {
					tryMove(leftFile,rightFile);
				}
				else
					announceMoveComplete(leftFile, 0);
			}
		}
		else {
			tryMove(leftFile,rightFile);
		}
	}
	private void tryMove(File leftFile,File rightFile) {
		try {
			Files.move(leftFile.toPath(), rightFile.toPath(),StandardCopyOption.REPLACE_EXISTING);
			announceMoveComplete(leftFile, 1);
		}
		catch(Exception e){
			if(e.getClass().toString().equals(Constant.NONEFILE))
				commandResult.announcePathFindFailed();
			else if(e.getClass().toString().equals(Constant.EXCESSDENIED)) {
				commandResult.excessDenied();
				announceMoveComplete(leftFile, 0);
			}
		}
	}

}
