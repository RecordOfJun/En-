package view;

public class Information {
	public void showOSInformation(String version) {
		System.out.println(String.format("Microsoft Windows [Version %s]", version));
		System.out.println("(c) Microsoft Corporation. All rights reserved.");
	}
	
	public void showCurrentDirectory(String path) {
		System.out.println();
		System.out.print(path+">");
	}
	public void informNoneCommand(String userInput) {
		System.out.println(String.format("\'%s\' 은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\r\n"
				+ "배치 파일이 아닙니다.", userInput));
	}
}
