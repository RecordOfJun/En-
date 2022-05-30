package controller.commands.tranformation;



import java.io.File;
import java.nio.file.Files;
import java.nio.file.StandardCopyOption;
import java.util.Scanner;

import controller.commandExcution;
import model.DirectoryData;
import view.CommandResult;

public class COPY extends TransForm {

	public COPY(CommandResult commandResult, DirectoryData directoryData) {
		super(commandResult, directoryData);
		// TODO Auto-generated constructor stub
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
			if(result==1||result==3)
				commandResult.announceCopyComplete(1);
			else
				commandResult.announceCopyComplete(0);
		}
		
	}
	private void directoryCopy(File leftFile,File rightFile) {
		File[] childFiles=leftFile.listFiles();
		int completeCount=0;
		boolean isAll=false;
		for(int count=0;count<childFiles.length;count++) {
			if(childFiles[count].isFile()) {
				System.out.println(leftFile.getName()+"\\"+childFiles[count].getName());
				if(!isAll) {
					int result=fileCopy(childFiles[count], rightFile);
					if(result==1)
						completeCount++;
					else if(result==3) {
						completeCount++;
						isAll=true;
					}
					else if(result==0) {
						commandResult.announceCopyComplete(0);
						return;
					}
				}
				else {
					File temporaryFile=rightFile.getAbsoluteFile();
					if(temporaryFile.isDirectory())
						temporaryFile=new File(temporaryFile.getPath()+"\\"+childFiles[count].getName());
					tryCopy(childFiles[count], temporaryFile);
					completeCount++;
				}
			}
		}
		commandResult.announceCopyComplete(completeCount);
	}
	private int fileCopy(File leftFile,File rightFile) {
		if(rightFile.exists()&&rightFile.isDirectory())
			rightFile=new File(rightFile.getPath()+"\\"+leftFile.getName());
		if(getPath(leftFile).equals(getPath(rightFile))) {
			commandResult.announceCanNotCopySameFile();
			return 0;//오류
		}
		else if(rightFile.exists()) {//물어보기
			int result=0;
			switch(askCover(rightFile.getName())) {
				case 1:
					tryCopy(leftFile, rightFile);
					result=1;
					break;
				case 2:
					result=2;
					break;
				case 3:
					tryCopy(leftFile, rightFile);
					result=3;
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
			return 1;
		}
		catch(Exception e){
			if(e.getClass().toString().equals("class java.nio.file.NoSuchFileException"))
				commandResult.announcePathFindFailed();
			else if(e.getClass().toString().equals("class java.nio.file.AccessDeniedException")) {
				commandResult.excessDenied();
				announceMoveComplete(leftFile, 0);
				announceMoveComplete(leftFile, 0);
			}
			return 0;
		}
	}
}