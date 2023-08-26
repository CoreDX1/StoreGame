import { type BaseResponse } from "~/modules/types/BaseResponse";
import { type GameResponse } from "../Domain/GameResponse";
import { type GameRepository } from "../Domain/GameRepository";

class CreateApiRespository implements GameRepository {
    private GAME_URL: string = "http://localhost:5099/api/Game/List";

    public getId = async (id: number): Promise<BaseResponse<GameResponse>> => {
        const response = await fetch(`${this.GAME_URL}/${id}`);
        const game = await response.json();
        return game;
    };

    public getAll = async (): Promise<BaseResponse<GameResponse[]>> => {
        const response = await fetch(this.GAME_URL);
        const game = await response.json();
        return game;
    };
}

export const ApiGameRepository = new CreateApiRespository();
