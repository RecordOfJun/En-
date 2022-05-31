package controller.commands.tranformation;
import java.io.File;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.util.Scanner;

import controller.CommandExcution;
import model.DirectoryData;
import utility.Constant;
import view.CommandResult;

public class COPY extends TransForm {

	public COPY(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
	}

	@Override
	protected void transferFile(String rightPath) {
		File leftFile=new File(getPath(path));
		synchronizeFile();
		movePath(rightPath);
		File rightFile=new File(getPath(path));
		if(leftFile.isDirectory()) {
			directoryCopy(leftFile,rightFile);
		}
		else if(leftFile.isFile()) {
			int result=fileCopy(leftFile, rightFile);
			if(result==Constant.ANSWERYES||result==Constant.ANSWERALL)
				commandResult.announceCopyComplete(1);
			else
				commandResult.announceCopyComplete(0);
		}
		
	}
	private void directoryCopy(File leftFile,File rightFile) {
		File[] childFiles=leftFile.listFiles();
		int completeCount=0;
		boolean isAll=false;
		boolean isCopied=false;
		for(int count=0;count<childFiles.length;count++) {
			if(childFiles[count].isFile()) {
				commandResult.showFileName(leftFile.getName(), childFiles[count].getName());
				if((!rightFile.exists()||rightFile.isFile())&&!isCopied) {
					int result=fileCopy(childFiles[count], rightFile);
					if(result==Constant.ANSWERYES||result==Constant.ANSWERALL) {
						completeCount++;
						isCopied=true;
					}
				}
				else if(rightFile.isDirectory()) {
					if(!isAll) {
						int result=fileCopy(childFiles[count], rightFile);
						if(result==Constant.ANSWERYES)
							completeCount++;
						else if(result==Constant.ANSWERALL) {
							completeCount++;
							isAll=true;
						}
						else if(result==Constant.RESULTERROR) {
							commandResult.announceCopyComplete(0);
							return;
						}
					}
					else {
						File temporaryFile=rightFile.getAbsoluteFile();
						if(temporaryFile.isDirectory())
							temporaryFile=new File(temporaryFile.getPath()+Constant.BACKSLASH+childFiles[count].getName());
						tryCopy(childFiles[count], temporaryFile);
						completeCount++;
					}
				}
			}
		}
		commandResult.announceCopyComplete(completeCount);
	}
	private int fileCopy(File leftFile,File rightFile) {
		if(rightFile.exists()&&rightFile.isDirectory())
			rightFile=new File(rightFile.getPath()+Constant.BACKSLASH+leftFile.getName());
		if(getPath(leftFile).equals(getPath(rightFile))) {
			commandResult.announceCanNotCopySameFile();
			return 0;//오류
		}
		else if(rightFile.exists()) {//물어보기
			int result=0;
			switch(askCover(rightFile.getName())) {
				case Constant.ANSWERYES:
					tryCopy(leftFile, rightFile);
					result=Constant.ANSWERYES;
					break;
				case Constant.ANSWERNO:
					result=Constant.ANSWERNO;
					break;
				case Constant.ANSWERALL:
					tryCopy(leftFile, rightFile);
					result=Constant.ANSWERALL;
					break;
			}
			return result;
		}
		else 
			return tryCopy(leftFile, rightFile);
	}
	private int tryCopy(File leftFile,File rightFile) {
		try {
			Files.copy(leftFile.toPath(), rightFile.toPath(),StandardCopyOption.REPLACE_EXISTING);
			return Constant.RESULTSUCESS;
		}
		catch(Exception e){
			if(e.getClass().toString().equals(Constant.NONEFILE))
				commandResult.announcePathFindFailed();
			else if(e.getClass().toString().equals(Constant.EXCESSDENIED)) {
				commandResult.excessDenied();
			}
			return Constant.RESULTERROR;
		}
	}
}