<?php

namespace Database\Seeders;

use App\Models\cities;
use Illuminate\Database\Seeder;

class CitySeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        cities::factory()
            ->times(10)
            ->create();
        //
    }
}
