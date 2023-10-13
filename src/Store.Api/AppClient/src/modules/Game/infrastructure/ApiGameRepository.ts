import { type BaseResponse } from "~/modules/types/BaseResponse";
import { type GameResponse } from "../Domain/GameResponse";
import { type GameRepository } from "../Domain/GameRepository";
import { API_URL } from "~/config";

class CreateApiRespository implements GameRepository {
    private GAME_URL: string = `${API_URL}/game`;

    public getId = async (id: number): Promise<BaseResponse<GameResponse>> => {
        const response = await fetch(`${this.GAME_URL}/${id}`);
        const game = await response.json();
        return game;
    };

    public getAll = async (): Promise<BaseResponse<GameResponse[]>> => {
        const response = await fetch(`${this.GAME_URL}`);
        const game = await response.json();
        return game;
    };
}

export const ApiGameRepository = new CreateApiRespository();
